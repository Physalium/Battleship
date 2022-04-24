export interface Coordinates {
  row: number;
  column: number;
}

export interface Ship {
  name: string;
  size: number;
  hitsTaken: number;
  isSunk: boolean;
}

export interface Tile {
  coordinates: Coordinates;
  ship: Ship;
  isHit: boolean;
  isInCheckerboardPattern: boolean;
}

export interface Board {
  tiles: Tile[];
}

export interface Player {
  name?: any;
  board: Board;
  ships: Ship[];
  hasLost: boolean;
}

export interface Shot {
  hitPosition: Coordinates;
  wasHit: boolean;
  sunkenShipName: string;
}

export interface GenerateGameResponse {
  player1: Player;
  player2: Player;
  shots: Shot[];
  winnerName?: any;
}
