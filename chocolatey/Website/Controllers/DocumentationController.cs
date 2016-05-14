﻿// Copyright 2011 - Present RealDimensions Software, LLC, the original 
// authors/contributors from ChocolateyGallery
// at https://github.com/chocolatey/chocolatey.org,
// and the authors/contributors of NuGetGallery 
// at https://github.com/NuGet/NuGetGallery
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Web.Mvc;

namespace NuGetGallery.Controllers
{
    public class DocumentationController : Controller
    { 
        
        private readonly IFileSystemService _fileSystem;

        public DocumentationController(IFileSystemService fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public ActionResult Documentation(string docName)
        {
            docName = docName.Replace("-", "");

            var fileExists = _fileSystem.FileExists(Server.MapPath("~/Views/Documentation/{0}.cshtml".format_with(docName)));

            if (fileExists)
            {
                return View(docName);
            }

            return RedirectToAction("PageNotFound", "Error");
        }

    }
}
