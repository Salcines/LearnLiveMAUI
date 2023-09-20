using People.Models;

namespace People;

public class PersonRepository
{
	private readonly string _databasePath;
	private SQLiteAsyncConnection _connection;

	public PersonRepository(string databasePath)
	{
		_databasePath = databasePath;
	}

	public string StatusMessage { get; set; }


	private async Task Init()
	{
		if (_connection != null)
		{
			return;
		}

		_connection = new SQLiteAsyncConnection(_databasePath);
		await _connection.CreateTableAsync<Person>();
	}

	public async Task AddNewPersonAsync(string name)
	{
		try
		{
			await Init();

			//name has been entered guard clause
			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("A valid name is required");
			}

			var result = await _connection.InsertAsync(new Person {Name = name});

			StatusMessage = string.Format($"{result} record(s) added (Name: {name}");
		}
		catch (Exception ex)
		{
			StatusMessage = string.Format($"Failed to add {name}. Error: {ex}");
		}
	}

	public async Task<List<Person>> GetAllPeopleAsync()
	{
		try
		{
			await Init();

			return await _connection.Table<Person>().ToListAsync();
		}
		catch (Exception ex)
		{
			StatusMessage = string.Format($"Failed to retrieve data. {ex.Message}");
		}

		return new List<Person>();
	}
}
