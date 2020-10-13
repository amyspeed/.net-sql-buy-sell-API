using System;
using Microsoft.AspNetCore.Mvc;
using buy_and_sell_dotNetAPI.Models;
using buy_and_sell_dotNetAPI.Data;
using AutoMapper;
using buy_and_sell_dotNetAPI.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;

namespace buy_and_sell_dotNetAPI.Controllers
{
    // api/listings
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly IListingRepo _repository;
        private readonly IMapper _mapper;

        public ListingsController(IListingRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //This line was created for Test purposes in the initial set up:
        //private readonly MockListingRepo _repository = new MockListingRepo();

        //GET api/listings
        [HttpGet]
        public ActionResult <IEnumerable<ListingReadDto>> GetAllListings()
        {
            var listingItems = _repository.GetAllListings();

            return Ok(_mapper.Map<IEnumerable<ListingReadDto>>(listingItems));

        }


        //GET api/listings/{id}
        [HttpGet("{id}", Name = "GetListingById")]
        public ActionResult<ListingReadDto> GetListingById(int id)
        {
            var listingItem = _repository.GetListingById(id);
            if (listingItem != null)
            {
                return Ok(_mapper.Map<ListingReadDto>(listingItem));
            }
            return NotFound();
        }

        //GET api/listings/user/{userId}
        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<ListingReadDto>> GetListingsByUserId(string userId)
        {
            var listingItems = _repository.GetListingsByUserId(userId);

            return Ok(_mapper.Map<IEnumerable<ListingReadDto>>(listingItems));

        }

        //POST api/listings
        [HttpPost]
        public ActionResult<ListingReadDto> CreateListing(ListingCreateDto listingCreateDto)
        {
            var listingModel = _mapper.Map<Listing>(listingCreateDto);
            _repository.CreateListing(listingModel);
            _repository.SaveChanges();

            var listingReadDto = _mapper.Map<ListingReadDto>(listingModel);

            return CreatedAtRoute(nameof(GetListingById), new { Id = listingReadDto.Id }, listingReadDto);

        }

        //PUT api/listings/{id}
        //This requires the entire data object
        [HttpPut("{id}")]
        public ActionResult UpdateListing(int id, ListingUpdateDto listingUpdateDto)
        {
            var listingModelFromRepo = _repository.GetListingById(id);
            if (listingModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(listingUpdateDto, listingModelFromRepo);

            _repository.UpdateListing(listingModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        //PATCH api/listings/{id}
        //This is a partial data update
        [HttpPatch("{id}")]
        public ActionResult PartialListingUpdate(int id, JsonPatchDocument<ListingUpdateDto> patchDoc)
        {
            var listingModelFromRepo = _repository.GetListingById(id);
            if (listingModelFromRepo == null)
            {
                return NotFound();
            }
            var listingToPatch = _mapper.Map<ListingUpdateDto>(listingModelFromRepo);
            patchDoc.ApplyTo(listingToPatch, ModelState);

            if (!TryValidateModel(listingToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(listingToPatch, listingModelFromRepo);

            _repository.UpdateListing(listingModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/listings/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteListing(int id)
        {
            var listingModelFromRepo = _repository.GetListingById(id);
            if (listingModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteListing(listingModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
