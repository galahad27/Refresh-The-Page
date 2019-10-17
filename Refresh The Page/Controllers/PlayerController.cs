using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;

using Refresh_The_Page.Filters;
using Refresh_The_Page.Results;
using Refresh_The_Page.Models;
using Refresh_The_Page.Utility;
using GameDataAccess;

namespace Refresh_The_Page.Controllers
{
    [Log]
    public class PlayerController : ApiController
    {
        // Get: api/Player
        public IHttpActionResult Get()
        {
            List<Player> playerList = new List<Player>();
            List<PlayerResponse> responseList = new List<PlayerResponse>();

            using (Refresh_The_PageEntities entities = new Refresh_The_PageEntities())
            {
                playerList = entities.Players.ToList();
            }
            foreach(Player player in playerList)
            {
                responseList.Add(PlayerResponse.DataToResponse(player));
            }
            string json = JsonConvert.SerializeObject(responseList);
            return new OkResult(json, Request);
        }

        // Get: api/Player/1
        public IHttpActionResult Get(string id)
        {
            Player player;

            using (Refresh_The_PageEntities entities = new Refresh_The_PageEntities())
            {
                player = entities.Players.FirstOrDefault(e => e.Id == id);
            }
            if(player == null)
            {
                return NotFound();
            }
            PlayerResponse response = PlayerResponse.DataToResponse(player);
            string json = JsonConvert.SerializeObject(response);
            return new OkResult(json, Request);
        }
        
        // Post: api/Player
        public IHttpActionResult Post(Player player)
        {
            player.Id = Guid.NewGuid().ToString();
            byte[] salt = Util.GetSalt();
            string hash = Util.Hash(player.Password, salt);
            player.Password = hash;
            player.Salt = Convert.ToBase64String(salt);
            using (Refresh_The_PageEntities entities = new Refresh_The_PageEntities())
            {
                try
                {
                    entities.Players.Add(player);
                    entities.SaveChanges();
                }
                catch(System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    foreach(var eve in ex.EntityValidationErrors)
                    {
                        foreach(var ve in eve.ValidationErrors)
                        {
                            ex.Data.Add(ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    Logger.WriteError(ex);
                    return InternalServerError();
                }
                
            }
            return new OkResult(Request);
        }

        // Patch: api/Player/1
        public void Patch(int id, Player player)
        {

        }
        
        // Delete: api/Player/1
        public void Delete(string id)
        {

        }
    }
}
