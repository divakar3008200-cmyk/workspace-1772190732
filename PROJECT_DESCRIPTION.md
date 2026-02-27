Project Title: Transportation Console Application

Overview
This project is a .NET console application that demonstrates core software engineering concepts through a small domain model and a menu-driven user interface. The application manages a collection of Transportation records in memory using a static list. It implements full Create, Read, Update, and Delete (CRUD) operations and is suitable as an educational exercise or an assignment for courses covering object-oriented programming, collections, and automated testing.

Learning Objectives
- Design a simple domain model and map it to an in-memory data store.
- Implement a console-based interactive menu that orchestrates application logic.
- Use collections and basic algorithms to support CRUD operations.
- Apply reflection-based testing techniques to verify structure and behavior.
- Practice building and running .NET projects and NUnit test suites.

Features
- Single domain model (Transportation) with multiple fields to represent real-world attributes.
- Menu-driven interaction for end users to add, view, update, and delete records.
- In-memory static list storage — no external database required, making the project self-contained.
- Seed data loader to populate initial records for demonstration and tests.
- Comprehensive NUnit test coverage that validates structure, functionality, edge cases, and error handling.

Solution Architecture
The project follows a minimal structure that keeps all runtime logic in the console entry point while placing the domain model in a dedicated Models folder.

- dotnetapp/Program.cs
  Purpose: Contains the entire runtime logic of the application, including the interactive menu loop, input handling, and CRUD operations that manipulate the in-memory collection. All methods used by the console UI are implemented in this file to keep the program compact for teaching and assessment.

- dotnetapp/Models/Transportation.cs
  Purpose: Defines the Transportation model used across the application. The class encapsulates the data fields and represents a single transportation record.

- nunit/test/TestProject/
  Purpose: Contains an automated NUnit test suite that validates the application's structure and behavior. Tests are implemented to use reflection when inspecting the application assembly and to capture console output when validating user-facing messages.

Domain Model: Transportation
The Transportation model represents a transport resource with the following attributes (types given at a conceptual level):
- TransportID (integer): A numeric identifier assigned internally.
- VehicleNumber (string): A unique or semi-unique vehicle identifier (used as a lookup key in some operations).
- Type (string): The transport type (for example, "Bus", "Truck", "Van").
- Capacity (integer): Seating or load capacity as an integer value.
- DriverName (string): Name of the assigned driver or operator.
- IsOperational (boolean): Indicates whether the vehicle is currently operational.

API / Methods Reference (Program.cs)
Note: The application is a console app; "API" here refers to public methods exposed in Program.cs for purposes of organization and testing.

- void SeedData()
  Description: Populates the internal in-memory list with a small number of sample Transportation records for demonstration and test setups.

- void AddTransportationFromConsole()
  Description: Reads user input from the console to create and add a new Transportation record into the static collection. Performs basic validation of required fields and assigns an internal identifier.

- string AddTransportation(Transportation transport)
  Description: Internal helper used by tests and program flows to add a Transportation instance into the static collection. Returns a status message or identifier to indicate success.

- void DisplayAllTransportations()
  Description: Writes the current collection of Transportation records to the console. If the collection is empty, a clear informative message is printed.

- void DisplayLimitedTransportations(int limit)
  Description: Writes up to the specified number of Transportation records to the console. Useful for verifying pagination-like behavior or limiting output in demonstrations.

- bool UpdateTransportation(string vehicleNumber, Action<Transportation> updateAction)
  Description: Locates a Transportation record by a lookup key (e.g., VehicleNumber) and applies the provided update action. Returns a boolean indicating whether an update occurred.

- bool DeleteTransportation(string vehicleNumber)
  Description: Removes the Transportation record matching the provided lookup key from the collection. Returns a boolean indicating success or failure.

- void Main(string[] args)
  Description: The application entry point. Presents the interactive menu, dispatches user selections to the appropriate helper methods, and terminates on user request.

Testing Strategy and Coverage
The project includes a dedicated NUnit test suite designed to validate the application on multiple levels. The testing strategy emphasizes both structural verification and behavioral tests.

Categories Covered
- File and type existence: Verify that the expected model and program files and types exist in the compiled assembly.
- Method and property existence: Use reflection to ensure public methods and properties required for CRUD behaviors are present with expected signatures.
- Functional CRUD tests: Use reflection and assembly-bound invocation to add, read, update, and delete Transportation records and assert expected outcomes.
- Console output validation: Capture console output to assert that user-facing messages for success, failure, and empty collections are informative and correctly formatted.
- Negative and boundary conditions: Tests cover cases such as deleting or updating non-existent records, adding invalid entries, and limiting output to fewer than available records.

Test Implementation Notes
- Tests rely on reflection to discover and interact with application types and members; they do not reference application types directly at compile-time. This ensures independence between the test assembly and implementation details and aligns with an assessment-style testing approach.
- Console interactions are validated by redirecting and capturing standard output streams where necessary. Tests do not require interactive input; programmatic helper methods are used or input is simulated where applicable.

Build and Run Instructions
The project is a .NET console application and uses the .NET CLI for build and test operations. The following commands are relevant and sufficient to compile, run, and test the project from a command-line environment with the .NET SDK installed.

- Restore dependencies (if necessary): dotnet restore
- Build the solution/project: dotnet build ./dotnetconsole/dotnetapp
- Run the console application: dotnet run --project ./dotnetconsole/dotnetapp
  * Once running, follow the on-screen menu to add, list, update, or delete Transportation records.
- Run the automated tests: dotnet test ./dotnetconsole/nunit/test/TestProject

Assessment / Grading Guidance
For an educational assignment, grading can focus on the following criteria:
- Correctness: CRUD operations correctly mutate and report on the in-memory collection.
- Robustness: The application handles invalid input and nonexistent records gracefully.
- Test coverage: The NUnit suite adequately verifies the structure and behavior described in this document.
- Code organization: The domain model is separated into a Models folder; runtime logic remains in Program.cs as required.

Extensibility Suggestions (optional)
- Replace the static in-memory list with a repository pattern backed by an in-memory database (for example, an EF Core InMemory provider) to demonstrate data layer separation.
- Move business logic out of Program.cs into service classes to allow easier unit testing without console coupling.
- Add serialization (JSON) to persist the in-memory collection between runs.

Location of Artifacts
- Application code: dotnetconsole/dotnetapp/
- Domain model: dotnetconsole/dotnetapp/Models/Transportation.cs
- Tests: dotnetconsole/nunit/test/TestProject/
- This description: PROJECT_DESCRIPTION.md (root of workspace)

End of description.