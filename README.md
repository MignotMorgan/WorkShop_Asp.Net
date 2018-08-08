# NET.Core Aps.Net MVC

https://docs.microsoft.com/fr-fr/aspnet/core/tutorials/first-mvc-app-xplat/start-mvc?view=aspnetcore-2.1

## Installer .NET Core
#### https://www.microsoft.com/net/download/dotnet-core/2.1
#### (ubuntu16-04) : https://www.microsoft.com/net/download/linux-package-manager/ubuntu16-04/sdk-2.1.302
	wget -q https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb
	sudo dpkg -i packages-microsoft-prod.deb

	sudo apt-get install apt-transport-https
	sudo apt-get update
	sudo apt-get install dotnet-sdk-2.1


## créer un site asp.NET MVC
	mkdir MvcMovie
	cd MvcMovie
	dotnet new mvc


## lancer le site
	F5 dans Visual Code
	ou
	dotnet run


## se connecter au site (Your connection is not secure)
	1 cliquer sur Advanced
	2 cliquer sur Add Exception...
	3 décocher la case Permanently store this exception
	4 cliquer sur Confirm Security Exception


## Explorer le fichier _Layout.cshtml
#### page maître du site.

Ajouter un boutton Test vers le Controller

	// ligne 36 
	<li><a asp-area="" asp-controller="Test" asp-action="Index">Test</a></li>




## créer un Controller
#### créer un fichier TestControllers.cs dans le dossier Controllers/
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using MvcMovie.Models;

	namespace MvcMovie.Controllers
	{
		public class TestController : Controller
		{
			public IActionResult Index()
			{
				ViewData["montest"] = "mon test";
				return View();
			}
		}
	}


## créer une View
#### créer un fichier Index.cshtml dans le dossier Views/Test/
	<h1>TEST</h1>
	<h2>@ViewData["montest"]</h2>


## Créer un Model
#### créer un fichier MonTest.cs dans le dossier Models/

	using System;

	namespace MvcMovie.Models
	{
		public class MonTest
		{
			public string Name { get; set; }

			public MonTest(string name = "monnom")
			{
				Name = name;
			}
		}
	}

#### remplacer dans le fichier Controllers/TestController.cs
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using MvcMovie.Models;

	namespace MvcMovie.Controllers
	{
		public class TestController : Controller
		{
			public IActionResult Index()
			{
				ViewData["montest"] = "mon test";
				MonTest montest = new MonTest("classe MonTest"); 
				return View(montest);
			}
		}
	}

#### remplacer dans le fichier Views/Test/Index/cshtml
	@model MvcMovie.Models.MonTest

	@using MvcMovie.Models;

	<h1>TEST</h1>
	<h2>@ViewData["montest"]</h2>
	<h2>@Model.Name</h2>



## Envoide paramètres au fonction du Controller
##### créer une nouvelle fonction dans Controllers/TestController.cs
	public IActionResult FuncTest(int id = 0, string name = "pas de nom")
	{
		ViewBag.id = id;
		ViewBag.name = name;
		return View();
	}
#### créer une nouvelle vue dans Views/Test qui porte le même nom que la fonction. (Views/Test/FuncTest.cshtml)
	<h1>FuncTest</h1>
	<h3>@ViewBag.id</h3>
	<h3>@ViewBag.name</h3>
##### tester l'url suivant:
	https://localhost:5001/Test/FuncTest?id=3&name="ceci est un  nom"

ou

	https://localhost:5001/Test/FuncTest/15/



