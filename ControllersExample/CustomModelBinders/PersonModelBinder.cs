using ControllersExample.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ControllersExample.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            UserPerson person = new UserPerson();
            // First name and last name
            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;

                if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
                {
                    person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
                }
            }

            // Email
            if(bindingContext.ValueProvider.GetValue("Email").Length>0){
                person.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
            }

            // Password
            if(bindingContext.ValueProvider.GetValue("Password").Length>0){
                person.Password = bindingContext.ValueProvider.GetValue("Password").FirstValue;
            }

            // ConfirmPassword
            if(bindingContext.ValueProvider.GetValue("ConfirmPassword").Length>0){
                person.ConfirmPassword = bindingContext.ValueProvider.GetValue("ConfirmPassword").FirstValue;
            }

            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}