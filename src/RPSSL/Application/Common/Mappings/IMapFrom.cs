using AutoMapper;

namespace Application.Common.Mappings
{
    /// <summary>
    /// Represents the AutoMapper Mapping configuration.
    /// </summary>
    /// <typeparam name="T">Mapping source item.</typeparam>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// Method is responsible for Mapping item with the type of T to the mapping destination type.
        /// </summary>
        /// <param name="profile">Mapping profile item.</param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
