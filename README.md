# zhongwen-zhi-lu
React .NET 8 web app to track my personal chinese language learning progress

## Getting Started

### Backend

1. Navigate to the backend directory:
   ```sh
   cd zhongwen-zhi-lu/backend
   ```
2. Restore dependencies and run the backend:
   ```sh
   dotnet restore
   dotnet run
   ```

### Frontend

1. Open a new terminal and navigate to the frontend directory:
   ```sh
   cd zhongwen-zhi-lu/frontend
   ```
2. Install dependencies and start the React app:
   ```sh
   npm install
   npm start
   ```

The backend will be available at [http://localhost:5133](http://localhost:5133) and the frontend at [http://localhost:3000](http://localhost:3000).

### Seeding the Database

After running migrations, you can seed the database with initial data:

1. Make sure you have [sqlite3](https://sqlite.org/download.html) installed and available in your PATH.
2. Run the following commands in the `backend` directory (PowerShell syntax):

   ```powershell
   sqlite3 Data/zhongwen-zhi-lu.db ".read Data/Seeds/01_Seed_Category.sql"
   sqlite3 Data/zhongwen-zhi-lu.db ".read Data/Seeds/01_Seed_Template_Week.sql"
   sqlite3 Data/zhongwen-zhi-lu.db ".read Data/Seeds/01_Seed_Template_Phrase.sql"
   ```

### API Endpoints

- `GET /api/week/with-phrases`  
  Returns all weeks, each with their phrases and linked categories.

### CORS

If you access the backend from the frontend (different ports), CORS is enabled by default in the backend. If you encounter CORS issues, check your backend's `Program.cs` for CORS configuration.

### Troubleshooting

- If the frontend cannot reach the backend, ensure both are running and the ports in the URLs match those in `launchSettings.json` and your fetch requests.
