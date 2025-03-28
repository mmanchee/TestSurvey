# Multi-Page Survey Application

The **Multi-Page Survey Application** is an ASP.NET Core Razor Pages project that demonstrates how to build a robust, multi‑page survey with session‑based state management. With this application, users can progressively fill out survey pages and have their choice persist when navigating back and forth. At the end of the process, all data is combined into a comprehensive summary displayed on a Thank You page.

## Features

- **Multi‑Page Workflow:**  
  The survey is divided into several pages:
  - **Page1:** Collects the survey date and user name.
  - **Page2:** Collects a rating (using a range slider) and feedback.
  - **Page3:** Collects the user’s favorite color (via a select list) and an explanation (textarea).
  - **Page4:** Collects weather preference (via radio buttons) and emotional state (via checkbox multi‑select).
  - **ThankYou:** Displays a summary of all responses.

- **Persistent State:**  
  Uses session storage to save and restore input data across all pages. This enables users to navigate backward without losing data.

- **Server‑Side Validation:**  
  Each page uses data annotations to validate the input on the server side, with additional client‑side validation supported by Razor’s validation scripts.

- **Clean Navigation Flow:**  
  Razor Page handlers (via `asp-page-handler`) manage back, next, and submit operations, ensuring a smooth user experience.

- **Extensible Design:**  
  The architecture allows easy enhancement—such as adding review steps or additional pages—by following the established pattern of saving and merging form data.

## Project Structure

Below is an overview of the project structure:

```
MultiPageSurveyApp/
├── Pages/
│   ├── Index.cshtml         # Landing page with survey introduction and a "Start Survey" button.
│   ├── Page1.cshtml         # Survey Page1: Collects Date and Name.
│   ├── Page1.cshtml.cs
│   ├── Page2.cshtml         # Survey Page2: Collects Rating and Feedback.
│   ├── Page2.cshtml.cs
│   ├── Page3.cshtml         # Survey Page3: Collects Favorite Color and a "Why" explanation.
│   ├── Page3.cshtml.cs
│   ├── Page4.cshtml         # Survey Page4: Collects Weather and Feeling (multi‑select).
│   ├── Page4.cshtml.cs
│   └── ThankYou.cshtml       # Thank You page: Displays combined survey responses.
│       └── ThankYou.cshtml.cs
├── Models/
│   ├── SurveyPage1ViewModel.cs
│   ├── SurveyPage2ViewModel.cs
│   ├── SurveyPage3ViewModel.cs
│   └── SurveyPage4ViewModel.cs
├── Services/
│   └── ISurveyService.cs    # Interface to persist the survey.
├── TestSurvey.Abstractions.Models/
│   └── Survey.cs            # Domain model representing the full survey.
└── ...
```

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) (or later)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- Basic knowledge of C# and ASP.NET Core Razor Pages

### Installation

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/YourUsername/MultiPageSurveyApp.git
   cd MultiPageSurveyApp
   ```

2. **Restore NuGet Packages:**

   ```bash
   dotnet restore
   ```

3. **Build and Run the Application:**

   ```bash
   dotnet run
   ```

4. **Open in Your Browser:**

   Navigate to `https://localhost:5001` (or the URL provided in the console) to access the survey.

## Usage

1. **Start the Survey:**  
   On the landing page (`Index.cshtml`), click the **Start Survey** button.

2. **Complete Survey Pages:**  
   - **Page1:** Enter today’s date and your name.
   - **Page2:** Provide a survey rating and your feedback.
   - **Page3:** Choose your favorite color from the list and describe why.
   - **Page4:** Select the current weather (radio options) and check all feelings that apply.
   
   Use the **Back** and **Next** buttons on each page to navigate. Thanks to session persistence, your input remains intact even if you navigate backward.

3. **Submit and Review:**  
   On Page4, clicking **Submit** will validate all data, combine responses into a complete survey using the `Survey` domain model, save the survey with the business logic (via `ISurveyService`), and redirect you to the Thank You page.

4. **Thank You Page:**  
   See a summary of all your responses, including details from each page (date, name, rating, feedback, favorite color, reason, weather, and feelings).

## How It Works

- **Session Management:**  
  Each page’s code-behind file leverages session state to save and retrieve user input. For instance, after entering data in Page2, the application stores the data with:
  
  ```csharp
  HttpContext.Session.SetString("SurveyPage2", JsonSerializer.Serialize(SurveyPage2));
  ```
  
  When you return to a page, the `OnGet` method deserializes these values to repopulate the form.

- **Navigation and Handlers:**  
  Razor Pages handlers like `OnPostBack`, `OnPostNext`, and `OnPostSubmit` are mapped via the `asp-page-handler` attribute, cleanly separating navigation logic. This ensures that each navigation event triggers the correct business logic (validation, data persistence, or final submission).

- **Data Integration:**  
  On final submission, data from all pages is merged into a single `Survey` object, which is then processed by the survey service. This integrated approach makes it simple to extend or modify any part of the survey.

## Contributing

Contributions are welcome! Feel free to fork the repository, make improvements, and submit pull requests. For major changes, please open an issue first to discuss what you'd like to change.

## License

Distributed under the MIT License.

## Acknowledgments

- [Microsoft ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core)
- [Bootstrap](https://getbootstrap.com/)
- Inspiration from various community projects and examples.
- Many thanks to all contributors and users who provided feedback.
