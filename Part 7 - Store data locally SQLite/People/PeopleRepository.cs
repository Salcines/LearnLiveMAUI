namespace People;

public class PeopleRepository
{
	private readonly string _databasePath;

	public PeopleRepository(string databasePath)
	{
		_databasePath = databasePath;
	}

	public string StatusMessage { get; set; }

	//TODO: Add variable for the SQLite connection


	private void Init()
	{
		//TODO: Add code to initialize the repository
	}

	public void AddNewPerson(string name)
	{
		int result = 0;

		try
		{
			// TODO: Call Init()

			//name has been entered guard clause
			if (string.IsNullOrEmpty(name))
			{
				throw new Exception("A valid name is required");
			}

			// TODO: Insert the new person into the database

			result = 0;

			StatusMessage = string.Format($"{result} record(s) added (Name: {name}");
		}
		catch (Exception ex)
		{
			StatusMessage = string.Format($"Failed to add {name}. Error: {ex}");
		}
	}

	public List<Person> GetAllPeople()
	{
		//TODO: Init them retrieve a list of Person objects from the database into a list
		try
		{

		}
		catch (Exception ex)
		{
			StatusMessage = string.Format($"Failed to retrieve data. {ex.Message}");
		}

		return new List<Person>();
	}
}
