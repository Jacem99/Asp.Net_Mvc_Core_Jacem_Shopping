namespace Shopping_Test.IServices
{
    public interface IProxyGetListItems
    {
        Task<IEnumerable<SelectListItem>> AgeStages ();
        Task<IEnumerable<SelectListItem>> HumanClass();
        Task<IEnumerable<SelectListItem>> ClothsCalssification();
        Task<IEnumerable<SelectListItem>> Markas();
        Task<IEnumerable<SelectListItem>> IdentityRoles();
    }
}
