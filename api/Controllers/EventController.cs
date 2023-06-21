using api.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using model.Entities;
using repository.Interfaces;

namespace api.Controllers
{
    public class EventController : ApiBaseController
    {
        
        private readonly IUnitOkWork _unitOkWork;
        private readonly IMapper _mapper;
        public EventController(IUnitOkWork unitOkWork, IMapper mapper){
            _unitOkWork = unitOkWork;
            _mapper = mapper;
        }

        
        [HttpPost]
        public async Task CreateEvent(EventDto eventDto)
        {
            var newEvent = _mapper.Map<Event>(eventDto);

            
            
        }
    }
}