using Game_Unity.Context;
using Game_Unity.Models;
using Game_Unity.Repository;
using Game_Unity.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region ConnetionString
var ConnectionString = builder.Configuration.GetConnectionString("ConnectionBD");
builder.Services.AddDbContext<CropContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<BatchContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<CropPestsContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<PlagueContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<WeatherConditionsContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<SoilQualityContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<FertilizersContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<CropTreatmentContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<MaturationMonitoringContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<UserContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<GameContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<ScoreContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<SceneryContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<TimeCollectionTracksContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<DetectiveCluesContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<DetectiveContext>(Options => Options.UseSqlServer(ConnectionString));
builder.Services.AddDbContext<AvatarLocationContext>(Options => Options.UseSqlServer(ConnectionString));
#endregion

#region Repositorys
//builder.Services.AddScoped<IWeatherContitionRepository, WeatherConditionsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITimeCollectionTracksRepository, TimeCollectionTracksRepository>();
builder.Services.AddScoped<ISoilQualityRepository, SoilQualityRepository>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
builder.Services.AddScoped<IScenaryRepository, SceneryRepository>();
builder.Services.AddScoped<IPlagueRepository, PlagueRepository>();
builder.Services.AddScoped<IMaturationMonitoringRepository, MaturationMonitoringRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IFertilizersRepository, FertilizersRepository>();
builder.Services.AddScoped<IDetectiveRepository, DetectiveRepository>();
builder.Services.AddScoped<IDetectiveCluesRepository, DetectiveCluesRepository>();
builder.Services.AddScoped<ICropTreatmentRepository, CropTreatmentRepository>();
builder.Services.AddScoped<ICropPestsRepository, CropPestsRepository>();
builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<IBatchRepository, BatchRepository>();
builder.Services.AddScoped<IAvatarLocationRepository, AvatarLocationRepository>();
#endregion

#region Service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITimeCollectionTrackService, TimeCollectionTracksService>();
builder.Services.AddScoped<ISoilQualityService, SoilQualityService>();
builder.Services.AddScoped<IScoreService, ScoreService>();
builder.Services.AddScoped<ISceneryService,SceneryService>();
builder.Services.AddScoped<IPlagueService, PlagueService>();
builder.Services.AddScoped<IMaturationMonitoringService, MaturationMonitoringService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IFertilizersService, FertilizersService>();
builder.Services.AddScoped<IDetectiveService, DetectiveService>();
builder.Services.AddScoped<IDetectiveCluesService, DetectiveCluesService>();
builder.Services.AddScoped<ICropTreatmentService, CropTreatmentService>();
builder.Services.AddScoped<ICropService, CropService>();
builder.Services.AddScoped<ICropPestService, CropPestService>();
builder.Services.AddScoped<IBatchService, BatchService>();
builder.Services.AddScoped<IAvatarLocationService, AvatarLocationService>();

#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
