using People.Models;

namespace People;

public class PersonRepository
{
	private readonly string _databasePath;
	private SQLiteConnection _connection;

	public PersonRepository(string databasePath)
	{
		_databasePath = databasePath;
	}

	public string StatusMessage { get; set; }


	private void Init()
	{
		if (_connection != null)
		{
			return;
		}

		_connection = new SQLiteConnection(_databasePath);
		_connection.CreateTable<Person>();
	}

	public void AddNewPerson(string name)
	{
		try
		{
			Init();

			//name has been entered guard clause
			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("A valid name is required");
			}

			var result = _connection.Insert(new Person {Name = name});

			StatusMessage = string.Format($"{result} record(s) added (Name: {name}");
		}
		catch (Exception ex)
		{
			StatusMessage = string.Format($"Failed to add {name}. Error: {ex}");
		}
	}

	public List<Person> GetAllPeople()
	{
		try
		{
			Init();

			return _connection.Table<Person>().ToList();
		}
		catch (Exception ex)
		{
			StatusMessage = string.Format($"Failed to retrieve data. {ex.Message}");
		}

		return new List<Person>();
	}
}
