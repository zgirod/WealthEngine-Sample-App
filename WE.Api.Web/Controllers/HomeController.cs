using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WE.Api.Objects;
using WE.Api.Web.Models;

namespace WE.Api.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly string _apiKey;
        private readonly string _environment;
        public HomeController()
        {
            _apiKey = ConfigurationManager.AppSettings["WEAPiKey"].ToString();
            _environment = ConfigurationManager.AppSettings["WEApiEnvironment"].ToString();
        }

        [HttpGet]
        public ActionResult ByAddress(ByAddressModel model)
        {
            if (model == null) model = new ByAddressModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ByAddressPost(string firstName, string lastName, string address1, string address2, string city, string state, string zip)
        {
            var api = new WealthEngineApi(_apiKey, _environment, "v1");
            var response = await api.GetProfileByNameAndAddressAsync<FullProfileMatch>(firstName, lastName, address1, address2, city, state, zip);
            return View("ApiResult", null, JObject.Parse(response.RawContent).ToString(Formatting.Indented));
        }

        [HttpGet]
        public ActionResult ByEmail(ByEmailModel model)
        {
            if (model == null) model = new ByEmailModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ByEmailPost(string firstName, string lastName, string email)
        {
            var api = new WealthEngineApi(_apiKey, _environment, "v1");
            var response = await api.GetProfileByEmailAsync<FullProfileMatch>(email, firstName, lastName);
            return View("ApiResult", null, JObject.Parse(response.RawContent).ToString(Formatting.Indented));
        }

        [HttpGet]
        public ActionResult ByPhone(ByPhoneModel model)
        {
            if (model == null) model = new ByPhoneModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ByPhonePost(string firstName, string lastName, string phone)
        {
            var api = new WealthEngineApi(_apiKey, _environment, "v1");
            var response = await api.GetProfileByPhoneAsync<FullProfileMatch>(phone, firstName, lastName);
            return View("ApiResult", null, JObject.Parse(response.RawContent).ToString(Formatting.Indented));
        }

    }

}