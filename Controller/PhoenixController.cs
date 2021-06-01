using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SouthNests.Phoenix.Framework;
using SouthNests.PhoenixMobile.Translators;
using SouthNests.PhoenixMobile.Model;


namespace WebApplication1.Controller
{
    public class PhoenixController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }
        [HttpPost]
        public HttpResponseMessage LoginMobileUser(MobileUserSignup item)
        {
            if (item == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            AuthenticateUser au = PhoenixMobileUserTranslator.LoginMobileUser(item);

            var response = Request.CreateResponse<AuthenticateUser>(HttpStatusCode.Created, au);
            
            return response;
        }

        [HttpPost]
        public HttpResponseMessage SignupMobileUser(MobileUserSignup item)
        {
            AuthenticateUser au = PhoenixMobileUserTranslator.SignupMobileUser(item);

            var response = Request.CreateResponse<AuthenticateUser>(HttpStatusCode.Created, au);

            return response;
        }

        
    }
}
