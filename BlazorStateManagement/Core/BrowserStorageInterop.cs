using Microsoft.JSInterop;

namespace BlazorStateManagement.Core
{
    public interface IBrowserStorageInterop
    {
        Task Save(Person person);
        Task<Person?> LoadPerson();
        Task Clear();
    }

    public class BrowserStorageInterop : IBrowserStorageInterop
    {
        private readonly IJSRuntime _jsRuntime;
        private const string LocalStorageDemoKey = "_state_management";

        public BrowserStorageInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task Clear()
        {
            await _jsRuntime.InvokeVoidAsync("ClearPersonFromLocalStorage", LocalStorageDemoKey);
        }

        public async Task<Person?> LoadPerson()
        {
            var personJson = await _jsRuntime.InvokeAsync<string>("LoadPersonFromLocalStorage", LocalStorageDemoKey);
            
            if(string.IsNullOrEmpty(personJson))
            {
                return null;
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(personJson);
        }

        public async Task Save(Person person)
        {
            string personJson = Newtonsoft.Json.JsonConvert.SerializeObject(person);
            await _jsRuntime.InvokeVoidAsync("SavePersonToLocalStorage", LocalStorageDemoKey, personJson);
        }
    }
}
