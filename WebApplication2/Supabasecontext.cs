using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Supabase.Gotrue;
using System.Reflection;
using System.Runtime.Serialization;

namespace WebApplication2
{
    public class SupaBaseContext
    {
        public SupaBaseContext()
        {

        }

        public async Task<List<User>> GetUsers(Supabase.Client _supabaseClient)
        {
            try
            {
                var result = await _supabaseClient.From<User>().Get();
                return result.Models;
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        public async Task InsertUsers(Supabase.Client _supabaseClient, User user)
        {
            try
            {
                await _supabaseClient.From<User>().Insert(user);
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<string> updateUserName(Supabase.Client _supabaseClient, updatingName user)
        {
            try
            {
                await _supabaseClient.From<User>().Where(x => x.id == user.id).Set(x => x.name, user.name).Update();
                return "Успешно!";
            }
            catch (Exception ex)
            {
                return "Ошибка!";
            }

        }

        public async Task<string> updateUserEmail(Supabase.Client _supabaseClient, updatingEmail user)
        {
            try
            {
                await _supabaseClient.From<User>().Where(x => x.id == user.id).Set(x => x.email, user.email).Update();
                return "Успешно!";
            }
            catch (Exception ex)
            {
                return "Ошибка!";
            }

        }

        public async Task<string> updateUserPassword(Supabase.Client _supabaseClient, updatingPassword user)
        {
            try
            {
                await _supabaseClient.From<User>().Where(x => x.id == user.id).Set(x => x.password, user.password).Update();
                return "Успешно!";
            }
            catch (Exception ex)
            {
                return "Ошибка!";
            }

        }

        public async Task<string> deleteUser(Supabase.Client _supabaseClient, deleteUser user)
        {
            try
            {
                await _supabaseClient.From<User>().Where(x => x.id == user.id).Delete();
                return "Успешно!";
            }
            catch (Exception ex)
            {
                return "Ошибка!";
            }

        }

    }
}