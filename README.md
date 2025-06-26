# github-platform-demo

## Scope

- [x] Visual Studio 2022 and C#
- [x] DevEx / Developer Productivity
- [x] GitHub Copilot
- [x] GitHub Copilot Chat
- [x] GitHub Copilot Agent mode
- [x] GitHub Copilot Coding Agent
- [x] GitHub Actions
- [x] GitHub Codespaces
- [x] GitHub Advanced Security

## Pre-requisites

- Configure a 1ES GitHub Runner.

## Script

Introduce the GitHub Platform using the [slides](https://microsofteur-my.sharepoint.com/:b:/g/personal/remojansen_microsoft_com/EW4W9hqR0cZGlhOsogrudXsBJnbtE9rN0VGqvZUOf_tZWQ?e=PNbEc4).

### 1. Copilot chat (via Github.com)

Open the repo in GitHub and ask copilot chat some questions about it:

- What is this project?
- What tools do I need in my development environment to be able to run it?

### 2. Codespaces

Run the application.

Show the swagger documentation `https://localhost:XXXXXX/swagger/index.html`.
	
Show the existing `GetWeatherForecastAsync` endpoint `https://localhost:XXXXXX/weather/forecast?city=seville`.

### 3. Code suggestions (from code)

Tigger a copilot suggestion to add a new HTTP endpoint to the `WeatherForecastController` by pasting:

```csharp
[HttpGet("Historical", Name = "GetHistoricalWeather")]
````

Reload the swagger documentation `https://localhost:XXXXXX/swagger/index.html` to show the changes.

Show the new endpoint in action `https://localhost:XXXXXX/weather/historical?city=seville&month=2`.

### 4. Code suggestions (from comments)

Delete the new endpoint and create it again by triggering using code suggestion by comment:
	
```csharp
/* Add new method GetHistoricalWeather
	* The endpoint tales city and month as FormQuery parameters
	* the URL should be /Weather/Historical
*/
````

### 5. Next edit suggestion (NES)

Add a an interface for `WeatherForecastController`:

```csharp
interface IWeatherController
````

- Apply Next edit suggestion (NES):
	
```csharp
public class WeatherForecastController : ControllerBase, IWeatherForecastController
```

Add a new method for the interface:

```ts

```

### 5. Copilot chat (via Visual Studio)

TODO

#### 6. Copilot chat agent mode

TODO

