namespace Application.Commands.Activities;

public record GetActivitiesCommand(
    int Count,
    int Offset
);