# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project overview

Konversor is an ASP.NET Core MVC (.NET 8) web app offering small math/utility calculators (percentage
calculations, LCM/MMC, and more planned per the sidebar nav). UI text and validation messages are in
Portuguese (pt-BR). There is no database — each feature is a stateless calculation exposed via a
Controller → Service → ViewModel → View flow.

## Commands

Run these from the `Konversor` project directory (where `Konversor.csproj` lives), or add `--project Konversor`
when running from the repo root (`KonversorMVC`, next to `Konversor.sln`).

- Build: `dotnet build`
- Run (dev server with hot reload): `dotnet watch run`
- Run (no watch): `dotnet run`

There is no test project in this repo currently.

## Architecture

**Request flow per feature:** `Controller` (in `Controllers/`) receives form posts, calls a `Service`
(interface in `Services/I*.cs`, implementation in `Services/*.cs`, registered as `Scoped` in `Program.cs`),
and re-renders the `Index` view with a populated `ViewModel` (in `ViewModels/`).

**Service validation convention:** Services validate inputs and `throw new Exception("Entrada inválida!")`
(or a similarly localized message) on invalid input — they don't use a Result/error-object pattern.
Controllers catch exceptions from the service call and set `vm.Error = ex.Message` rather than letting
them propagate; they do not use exceptions for `ModelState` validation, which is checked separately via
`[Required]` attributes on the ViewModel.

**Two view-composition patterns exist, depending on how many operations the feature exposes:**
- *Single-operation feature* (e.g. `Mmc`): one `ViewModel` (`MmcViewModel`) with input/`Result`/`Error`
  properties, bound directly to the `Index` view. `MmcController.Index()` (GET) and `CalculateMmc()` (POST)
  both return `View("Index", vm)`.
- *Multi-operation feature* (e.g. `Porcentagem`): a page-level `ViewModel`
  (`PorcentagemPageViewModel`) aggregates one sub-ViewModel per operation (e.g. `PercentOfViewModel`,
  `IncreasePercentageViewModel`). `Views/Porcentagem/Index.cshtml` renders each sub-ViewModel through its
  own partial under `Views/Porcentagem/Partials/`, each with its own `<form asp-action="Calculate...">`
  posting to a dedicated controller action. Every POST action rebuilds the whole `PorcentagemPageViewModel`
  (setting only the one sub-ViewModel that was submitted) so the shared `Index` view can re-render.

When adding a new calculator operation to an existing multi-operation controller, follow the existing
pattern: add a method to the service interface + implementation, a ViewModel for that operation, a POST
action on the controller that builds and returns the page ViewModel, and a partial view wired into the
page's `Index.cshtml`.

**Navigation:** The sidebar in `Views/Shared/_Layout.cshtml` is a hand-maintained list of links grouped by
category ("Matemática", "Computação"). Several links are placeholders (`href="#"`) for features that
don't exist yet. When adding a new controller/feature, add its link here too.
