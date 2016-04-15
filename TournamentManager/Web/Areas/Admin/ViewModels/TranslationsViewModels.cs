using System.Collections.Generic;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class TranslationsIndexViewModel
    {
        public IEnumerable<Translation> Translations { get; set; }
        public bool ViewHtml { get; set; }
    }
}