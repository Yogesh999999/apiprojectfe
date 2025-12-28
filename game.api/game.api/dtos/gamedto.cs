namespace game.api.dtos;

public record class gamedto
(
    int id, 
    string name,
    string genre,
    int price,
    DateOnly releasedate
);
