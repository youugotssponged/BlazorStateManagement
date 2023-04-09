window.SavePersonToLocalStorage = (key, personJson) =>
{
    localStorage.setItem(key, personJson);
}

window.ClearPersonFromLocalStorage = (key) =>
{
    localStorage.removeItem(key);
}

window.LoadPersonFromLocalStorage = (key) =>
{
    return localStorage.getItem(key);
}