using AutoMapper;
using Youtube.Application.Interfaces.AutoMapper;
using IMapper = AutoMapper.IMapper;


namespace Youtube.Mapper.AutoMapper;

public class Mapper : Youtube.Application.Interfaces.AutoMapper.IMapper
{
    public static List<TypePair> typePairs = new();

    private IMapper MapperContenier;

    public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
    {
        Config<TDestination,TSource>(5,ignore);

        return MapperContenier.Map<TSource,TDestination>(source); 

    }

    public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null)
    {
        Config<TDestination,TSource>(5,ignore);

        return MapperContenier.Map<IList<TSource>,IList<TDestination>>(sources); 
    }

    public TDestination Map<TDestination>(object source, string? ignore = null)
    {
         Config<TDestination,object>(5,ignore);

        return MapperContenier.Map<object,TDestination>(source); 

    }

    public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
    {
            Config<TDestination,object>(5,ignore);

        return MapperContenier.Map<IList<object>,IList<TDestination>>(source); 
    }
    protected void Config<TDestination,TSource>(int depth =  5,string? ignore = null)
    {
        var typePair = new TypePair(typeof(TSource), typeof(TDestination));
        if(typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType && ignore is null)){
            return;
        }
        typePairs.Add(typePair);
        var config = new MapperConfiguration(cfg => {
            foreach(var pair in typePairs) {
                if (ignore is not null ){
                    cfg.CreateMap(pair.SourceType, pair.DestinationType).MaxDepth(depth).ForMember(ignore, x => x.Ignore()).ReverseMap();
                }
                else{
                    cfg.CreateMap(pair.SourceType,pair.DestinationType).MaxDepth(depth).ReverseMap();
                }
            }
        });
        MapperContenier = config.CreateMapper();
    }
}