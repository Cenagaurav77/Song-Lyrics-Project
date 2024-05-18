using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var skyFullOfStars = new
{
    Title = "Sky Full Of Stars",
    Artist = "Cold Play",
    Lyrics = new[] { "'Cause you're a sky, 'cause you're a sky full of stars I'm gonna give you my heart 'Cause you're a sky, 'cause you're a sky full of stars'Cause you light up the path I don't care, go on and tear me apart I don't care if you do, ooh-ooh, ooh 'Cause in a sky, 'cause in a sky full of stars I think I saw you 'Cause you're a sky, 'cause you're a sky full of stars I wanna die in your arms, oh, oh-oh 'Cause you get lighter the more it gets dark I'm gonna give you my heart, oh I don't care, go on and tear me apart I don't care if you do, ooh-ooh, ooh 'Cause in a sky, 'cause in a sky full of stars I think I see you I think I see you 'Cause you're a sky, you're a sky full of stars Such a heavenly view You're such a heavenly view Yeah, yeah, yeah, ooh"
}
};

var shivers = new
{
    Title = "Shivers",
    Artist = "Ed Sheeran",
    Lyrics = new[] { "I took an arrow to the heart I never kissed a mouth that tastes like yours Strawberries and somethin' more Ooh yeah, I want it all Lipstick on my guitar (ooh) Fill up the engine, we can drive real far Go dancin' underneath the stars Ooh yeah, I want it all Mm, you got me feelin' like I wanna be that guy, I wanna kiss your eyes I wanna drink that smile, I wanna feel like I'm Like my soul's on fire, I wanna stay up all day and all night Yeah, you got me singin' like Ooh, I love it when you do it like that And when you're close up, give me the shivers Oh baby, you wanna dance 'til the sunlight cracks And when they say the party's over, then we'll bring it right back And we'll say, ooh, I love it when you do it like that And when you're close up, give me the shivers Oh baby, you wanna dance 'til the sunlight cracks And when they say the party's over, then we'll bring it right back Into the car On the backseat in the moonlit dark Wrap me up between your legs and arms Ooh, I can't get enough You know you could tear me apart (ooh) Put me back together and take my heart I never thought that I could love this hard Ooh, I can't get enough Mm, you got me feeling like I wanna be that guy, I wanna kiss your eyes I wanna drink that smile, I wanna feel like I'm Like my soul's on fire, I wanna stay up all day and all night Yeah, you got me singin' like Ooh, I love it when you do it like that And when you're close up, give me the shivers Oh baby, you wanna dance 'til the sunlight cracks And when they say the party's over, then we'll bring it right back And we'll say, ooh, I love it when you do it like that And when you're close up, give me the shivers Oh baby, you wanna dance 'til the sunlight cracks And when they say the party's over, then we'll bring it right back Baby, you burn so hot You make me shiver with the fire you got This thing we started, I don't want it to stop You know you make me shiver-er-er Baby, you burn so hot You make me shiver with the fire you got This thing we started, I don't want it to stop You know you make me shiver Yeah, you got me singin' like Ooh, I love it when you do it like that And when you're close up, give me the shivers Oh baby, you wanna dance 'til the sunlight cracks And when they say the party's over, then we'll bring it right back (oh no) And we'll say, ooh, I love it when you do it like that And when you're close up, give me the shivers Oh baby, you wanna dance 'til the sunlight cracks And when they say the party's over, then we'll bring it right back, hey" }
};

var sunflower = new
{
    Title = "Sunflower",
    Artist = "Post Malone",
    Lyrics = new[] { "Ayy, ayy, ayy, ayy (ooh) Ooh, ooh, ooh, ooh (ooh) Ayy, ayy Ooh, ooh, ooh, ooh Needless to say, I keep her in check She was a bad-bad, nevertheless (yeah) Callin' it quits now, baby, I'm a wreck (wreck) Crash at my place, baby, you're a wreck (wreck) Needless to say, I'm keeping her in check She was all bad-bad, nevertheless Callin' it quits now, baby, I'm a wreck Crash at my place, baby, you're a wreck Thinkin' in a bad way, losin' your grip Screamin' at my face, baby, don't trip Someone took a big L, don't know how that felt Lookin' at you sideways, party on tilt Ooh-ooh-ooh Some things you just can't refuse She wanna ride me like a cruise And I'm not tryna lose Then you're left in the dust Unless I stuck by ya You're the sunflower I think your love would be too much Or you'll be left in the dust Unless I stuck by ya You're the sunflower You're the sunflower Every time I'm leavin' on you (ooh) You don't make it easy, no (no, no) Wish I could be there for you Give me a reason to, oh (oh) Every time I'm walkin' out I can hear you tellin' me to turn around Fightin' for my trust and you won't back down Even if we gotta risk it all right now, oh (now) I know you're scared of the unknown ('known) You don't wanna be alone (alone) I know I always come and go (and go) But it's out of my control And you'll be left in the dust Unless I stuck by ya You're the sunflower I think your love would be too much Or you'll be left in the dust Unless I stuck by ya You're the sunflower You're the sunflower (yeah)" }
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
}).WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/skyFullOfStars", () =>
{
    return Results.Json(skyFullOfStars);
});

app.MapGet("/shivers", () =>
{
    return Results.Json(shivers);
});

app.MapGet("/sunflower", () =>
{
    return Results.Json(sunflower);
});


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}