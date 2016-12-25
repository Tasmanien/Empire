using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BackEnd.Controllers
{
    public class BaseController : ApiController
    {
        /// <summary>
        /// Throws a Forbidden Action
        /// </summary>
        protected void Forbidden()
        {
            throw new HttpResponseException(HttpStatusCode.Forbidden);
        }

        /// <summary>
        /// Initializes the current Method for the App Controller.
        /// It will do some basic security checks
        /// </summary>
        /// <param name="controllerContext"></param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            // Check if we are authenticated
            //if (controllerContext.Request.Headers.Authorization.IsNotNull() &&
            //    controllerContext.Request.Headers.Authorization.Scheme == "Bearer")
            {
                //if (!CurrentUserHasAccess(Constants.PubliChem.Functionalities.ViewApp))
                //{
                //    Logger.WarnFormat("User with email {0} doesn't have access on this application. Returning Forbidden", currentUser.Email);
                //    Forbidden();
                //}
            }
        }
    }
}
