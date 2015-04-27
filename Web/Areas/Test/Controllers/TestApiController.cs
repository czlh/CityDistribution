using BLL.BaseInfo;
using Model.BaseInfo;
using Model.Domain;
using Model.SYS;
using Model.Test;
using Search;
using Service.SYS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Controllers;

namespace Web.Areas.Test.Controllers
{
    public class TestApiController : BaseApiController
    {
        UserInfoService userInfoService = new UserInfoService ();

        [HttpPost]
        public UserInfoEntity Create(UserInfoEntity user)
        {
            return userInfoService.Create(user);
        }

        [HttpGet]
        public UserInfoEntity GetById(string id)
        {
            return userInfoService.FindById(id);
        }

        [HttpPost]
        public IQueryable GetList(QueryModel qm)
        {
            return userInfoService.FindPage(qm);
        }

        [HttpPost]
        public UserInfoEntity GetInstance()
        {
            int index = new Random().Next(1000);
            return new UserInfoEntity()
            {
                UserName = index + "",
                PassWord = index + "" + index
            };
        }

        [HttpPut]
        public UserInfoEntity Update(string id, UserInfoEntity test)
        {
            return userInfoService.Update(test);
        }

        [HttpDelete]
        public void delete(string id)
        {
            userInfoService.Delete(id);
        }

        [HttpDelete]
        public void deletes(List<string> ids)
        {
            userInfoService.Deletes(ids);
        }
    }
}
