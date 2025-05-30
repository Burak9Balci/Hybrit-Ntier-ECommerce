using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.BusinessLogicLayer.Managers.Concretes;

namespace Project.WebAPI.Controllers.DomainControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRoleController : ControllerBase
    {
        IMapper _mapper;
        IAppRoleManager _appRoleManager;
        public AppRoleController(IMapper mapper,IAppRoleManager appRoleManager)
        {
            _appRoleManager = appRoleManager;
            _mapper = mapper;
        }
    }
}
