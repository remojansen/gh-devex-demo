# GitHub DevEx Demo

## Features

1. [Copilot chat (via Github.com)](#1-copilot-chat-via-githubcom)
2. [Codespaces](#2-codespaces)
3. [Code suggestions (from code)](#3-code-suggestions-from-code)
4. [Code suggestions (from comments)](#4-code-suggestions-from-comments)
5. [Next edit suggestion (NES)](#5-next-edit-suggestion-nes)
6. [Copilot chat (via Visual Studio)](#5-copilot-chat-via-visual-studio)
7. [Copilot chat agent mode (@workspace)](#6-copilot-chat-agent-mode-workspace)
8. [Copilot for CLI](#7-copilot-for-cli)
9. [Copilot chat agent mode (@github)](#8-copilot-chat-agent-mode-github)
10. [GitHub Actions](#9-github-actions)
11. [Coding Agent](#10-coding-agent)
12. [One platform](#11-one-platform)
13. [GHAS](#12-ghas)

## Script

Introduce the GitHub Platform using the [slides](./demo.pdf).

### 1. Copilot chat (via Github.com)

Open the repo in GitHub and ask copilot chat some questions about it:

- What is this project?
- What tools do I need in my development environment to be able to run it?

### 2. Codespaces

Run the application using a codespace.

Open a terminal (in codespace) and run the unit test:

```sh
dotnet test
```

Run the API:

```sh
dotnet run --project ./github-platform-demo-api/github-platform-demo-api.csproj
```

Show the swagger documentation `https://XXXXXX.app.github.dev/swagger/index.html`.
	
Show the existing `GetWeatherForecastAsync` endpoint `https://XXXXXX.app.github.dev/weather/forecast?city=seville`.

Open Visual Studio 2022 and run it (`http://localhost:XXXXXX/swagger/index.html`) to show that it works in both environments.

### 3. Code suggestions (from code)

Trigger a copilot suggestion to add a new HTTP endpoint to the `WeatherForecastController` by pasting some code`:

```csharp
[HttpGet("Historical", Name = "GetHistoricalWeather")]
````

Reload the swagger documentation `https://localhost:XXXXXX/swagger/index.html` to show the changes.

Show the new endpoint in action `https://localhost:XXXXXX/weather/historical?city=seville&month=2`.

### 4. Code suggestions (from comments)

Delete the new endpoint and create it again by triggering a code suggestion by comment:
	
```csharp
/* Add new method GetHistoricalWeather
* The endpoint takes city and month as FormQuery parameters
* the URL should be /Weather/Historical
*/
````

### 5. Next edit suggestion (NES)

Delete the new endpoint and create it again by adding the following to `interface IWeatherController`:

```csharp
Task<IEnumerable<WeatherForecast>> GetHistoricalWeatherAsync(string city, int month);
````

Highlight how the change was far away from the cursor because it is a NES.

### 5. Copilot chat (via Visual Studio)

Ask copilot something about the source code:

```
What is the `github_platform_demo_ioc` project used for?
```

```sh
What is a composition root?
```

### 6. Copilot chat agent mode (@workspace)

Explain how agents are different from standard chat mode.

Demo the @workspace agent:

```sh
@workspace Add a unit test for WeatherController.GetHistoricalWeatherAsync
```

> :warning: For this step you might need to switch to your personal account if the repo is in your personal account. Otherwise Copilot chat will tell you that it lacks permissions to create the new PR.

### 7. Copilot for CLI

Ask copilot CLI how to create a new branch:

```sh
gh copilot suggest "create a new branch named copilot-demo"
```

```sh
gh copilot suggest "commit and push my changes to branch copilot-demo"
```

### 8. Copilot chat agent mode (@github)

Ask the github agent to open a PR:

```sh
@github create a new PR from branch copilot-demo to main. Link the PR to issue #2.
```

Explain that you can create more agents with MCP.

### 9. GitHub Actions

Show the PR build checks.

### 10. Coding Agent

Create a new issue using copilot chat:

```sh
Draft an issue to add a new endpoint (HTTP GET /Weather/Alerts?city={city}) to the WeatherForecastController that
returns weather alerts. The issue should describe the steps to implement the endpoint.
Including changes to the domain model, the controller, mocks and unit tests. 
For simplicity the WeatherService should use hard coded data instead of reading from a real database.
```

Assign the new issue to the coding agent.

Show how the PR is created (Copilot session details).

### 11. One platform

Use the PR to highlight how everything is integrated as one platform. CI/CD, code reviews, issues, etc.

Reduces TCO and improves DevEx.

### 12. GHAS

  1. **Code Scanning**
  
      This feature uses GitHub's CodeQL engine to perform static application security testing (SAST). It scans your codebase for vulnerabilities, unsafe coding patterns, and logic flaws.

      - CodeQL builds a semantic database of your code and runs queries to detect issues.

      - Copilot Autofix can automatically suggest fixes for detected vulnerabilities.

      - Security Campaigns allow security teams to target and remediate historical vulnerabilities at scale.

  2. **Secret Scanning**

     Secret scanning detects sensitive information, like API keys, tokens, and credentials, that may have been accidentally committed to your repositories.

	  - It scans the entire git history and issues.

	  - Push Protection prevents secrets from being committed in the first place by blocking pushes that contain them.

	  - Supports over 200 token types and allows for custom patterns using regular expressions.

  3. **Dependency Review and Management**
  
     This feature helps you manage and secure your software supply chain by analyzing changes to dependencies.

      - Dependency Review shows the impact of dependency changes in pull requests.

      - Dependabot Alerts and Updates notify you of known vulnerabilities and can automatically open pull requests to update affected packages.

      - Custom Auto-Triage Rules let you manage alerts at scale by automating responses to Dependabot alerts

### 13. GitHub Spark

Use slides to summarize demo and discuss next steps.

