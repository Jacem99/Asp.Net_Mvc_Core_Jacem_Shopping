namespace Shopping_Test.IServices
{
    public interface IGetListItems
    {
        Task<List<SelectListItem>> AgeStages();
        Task<List<SelectListItem>> HumanClass();
        Task<List<SelectListItem>> ClothsCalssification();
        Task<List<SelectListItem>> Markas();
        Task<List<SelectListItem>> IdentityRoles();

    }
}
