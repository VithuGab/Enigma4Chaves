using System;


//Pode ser que o TileType ser movido para o TileObject
[Serializable]
public struct TilePosition : IEquatable<TilePosition> {
    public int x;
    public int y;
    public TileTypes tileType;

    public TilePosition(int x , int y) {
        this.x = x;
        this.y = y;
        this.tileType = TileTypes.Medo;
    }
    public TilePosition(int x , int y , TileTypes tileTypes) {
        this.x = x;
        this.y = y;
        this.tileType = tileTypes;
    }


    //Operadores
    public override bool Equals(object obj) {
        return obj is TilePosition position &&
               x == position.x &&
               y == position.y;
    }
    public static bool operator ==(TilePosition lhs , TilePosition rhs) { return lhs.x == rhs.x && lhs.y == rhs.y; }
    public static bool operator !=(TilePosition lhs , TilePosition rhs) {
        return !(lhs == rhs);
    }
    public static TilePosition operator +(TilePosition a , TilePosition b) {
        return new TilePosition(a.x + b.x , a.y + b.y);
    }
    public static TilePosition operator -(TilePosition a , TilePosition b) {
        return new TilePosition(a.x - b.x , a.y - b.y);
    }
    public override string ToString() {
        return $"X:{x} Y:{y} \n {tileType.ToString()}";
    }
    public bool Equals(TilePosition other) {
        return this == other;
    }

    public override int GetHashCode() {
        return HashCode.Combine(x , y , tileType);
    }
}

public enum TileTypes {
    Medo,
    Energia,
    Sangue,
    Morte,
    Conhecimento

}