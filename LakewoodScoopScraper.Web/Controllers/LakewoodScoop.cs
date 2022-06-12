using LakewoodScoopScraper.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LakewoodScoopScraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LakewoodScoop : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<NewsItem> Scrape()
        {
            return LakewoodScoopS.Scrape();
        }
    }
}
