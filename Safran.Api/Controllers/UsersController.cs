using Microsoft.AspNetCore.Mvc;
using Safran.Api.Data;
using Safran.Api.Data.Users;
using Safran.Api.Converters;
using Safran.Data.Users;
using System.Net;
using System.Security.Cryptography;
using Safran.Api.Security;

namespace Safran.Api.Controllers
{
    /// <summary>
    /// A class for the users routes 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserRepository repo, ICryptoTool crypto) : BaseController(repo)
    {
        private readonly ICryptoTool _cryptoTool = crypto;

        /// <summary>
        /// Gets the paged users list
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<UserSummaryDto>), 200)]
        public IActionResult Get(int page, int pageSize)
        {
            var res = _userRepository.Get(page, pageSize);
            return Ok(new PagedResult<UserSummaryDto>(res.Item1?.ToDto(), res.Item2));
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="userCreationDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(201)]
        public IActionResult Add([FromBody] UserCreationDto userCreationDto)
        {
            if (userCreationDto == null)
            {
                return BadRequest("null payload");
            }

            // inutile grace au contrat sur le modele
            //if(string.IsNullOrWhiteSpace(userCreationDto.Login))
            //{
            //    return BadRequest("un login doit être fourni");
            //}

            if (_userRepository.Exists(userCreationDto.Login))
            {
                return Conflict(); //potentiel pb de securité car permet de detecter les logins existants
            }

            _userRepository.Add(userCreationDto.Login, userCreationDto.Password);

            return Created();
        }

        /// <summary>
        /// Gets the user details
        /// </summary>
        /// <param name="id">the user id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(Guid id)
        {
            var res = _userRepository.Get(id);
            if(res == null)
            {
                return NotFound();
            }

            return Ok(res.ToDto());
        }


        /// <summary>
        /// Deletes the user
        /// </summary>
        /// <param name="id">the user Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(404)]
        public IActionResult Delete(Guid id)
        {
            var res = _userRepository.Delete(id);

            if(res == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes the user
        /// </summary>
        /// <param name="id">the user Id</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(404)]
        public IActionResult Delete(UserDto user)
        {
            var res = _userRepository.Update(user.ToDbModel());

            if(res == 0)
            {
                return NotFound();
            }

            return NoContent();
        }



        /// <summary>
        /// Deletes the user
        /// </summary>
        /// <param name="id">the user Id</param>
        /// <returns></returns>
        [HttpPut("Password")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePassword([FromBody] PasswordChange passwords)
        {
            if(passwords == null)
            {
                return BadRequest("empty payload");
            }

            if(!_userRepository.IsMatching(CurrentUser.Id.Value, _cryptoTool.Cypher(passwords.OldPassword)))
            {
                return BadRequest();
            }

            _userRepository.SetPassword(CurrentUser.Id.Value, _cryptoTool.Cypher(passwords.NewPassword));

            return NoContent();
        }
    }
}
