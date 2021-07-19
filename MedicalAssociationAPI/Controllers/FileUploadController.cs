using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace MedicalAssociationAPI.Controllers
{
    public class FileUploadController : ApiController
    {
        [HttpPost]
        [Route("api/UploadImage")]
        public IHttpActionResult UploadImage()
        {
            //string imageName = null;
            //var httpRequest = HttpContext.Current.Request;
            ////Upload Image
            //var postedFile = httpRequest.Files["image"];
            ////Create custom filename
            //if (postedFile != null)
            //{
            //    imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            //    imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            //    var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);
            //    postedFile.SaveAs(filePath);
            //}
            //return Ok();

            string sPath = "";
            try
            {
                int iUploadedCnt = 0;

                // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.

                sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/images/");

                HttpFileCollection hfc = HttpContext.Current.Request.Files;

                // CHECK THE FILE COUNT.
                for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                {
                    System.Web.HttpPostedFile hpf = hfc[iCnt];

                    if (hpf.ContentLength > 0)
                    {
                        // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                        if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                        {
                            // SAVE THE FILES IN THE FOLDER.
                            sPath = sPath + Path.GetFileName(hpf.FileName);
                            hpf.SaveAs(sPath/* + Path.GetFileName(hpf.FileName)*/);
                            iUploadedCnt = iUploadedCnt + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

            return Ok(sPath);
        }


        [HttpPost]
        [Route("api/UploadFile")]
        public IHttpActionResult UploadFile()
        {
            //string filename = null;
            //var httpRequest = HttpContext.Current.Request;
            ////Upload Image
            //var postedFile = httpRequest.Files["file"];
            ////Create custom filename
            //if (postedFile != null)
            //{
            //    filename = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            //    filename = filename + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            //    var filePath = HttpContext.Current.Server.MapPath("~/Downloads/" + filename);
            //    postedFile.SaveAs(filePath);
            //}
            string sPath = "";
            try
            {
                int iUploadedCnt = 0;

                // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.

                sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Downloads/");

                HttpFileCollection hfc = HttpContext.Current.Request.Files;

                // CHECK THE FILE COUNT.
                for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                {
                    System.Web.HttpPostedFile hpf = hfc[iCnt];

                    if (hpf.ContentLength > 0)
                    {
                        // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                        if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                        {
                            // SAVE THE FILES IN THE FOLDER.
                            hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
                            iUploadedCnt = iUploadedCnt + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

            return Ok(sPath);
        }

    }


}
