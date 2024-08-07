namespace kurs2_bloknot.Models
{
    public static class MappingExtansions
    {
        public static LoginServiceModel ToServiceModel(this LoginBindingModel source) =>
           new LoginServiceModel()
           {
               Email = source.Login,
               Password = source.Password
           };
    }
}
