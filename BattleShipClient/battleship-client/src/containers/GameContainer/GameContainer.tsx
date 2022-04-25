import { Box, Button, Container, Typography } from "@mui/material";
import Grid from "@mui/material/Grid";
import React, { useEffect, useState } from "react";
import { Player, Ship, Shot } from "../../api/types/games.types";
import { generateGameApi } from "../../api/utils.game";
import PlayerPanel from "../PlayerPanel/PlayerPanel";
import "./styles.scss";

function GameContainer() {
  const [firstPlayer, setFirstPlayer] = useState<Player>();
  const [secondPlayer, setSecondPlayer] = useState<Player>();
  const [shotsArray, setShotsArray] = useState<Shot[]>();
  const [shotCount, setShotCount] = useState<number>(0);
  const [isGameFinished, setIsGameFinished] = useState<boolean>(false);
  const [isFirstPlayerTurn, setIsFirstPlayerTurn] = useState<boolean>(true);
  const [winnerName, setWinnerName] = useState<string>("");

  const onGenerate = () => {
    generateGameApi()
      .then((response) => {
        console.log(response.data);
        setFirstPlayer(response.data.player1);
        setSecondPlayer(response.data.player2);
        setShotsArray(response.data.shots);
        setWinnerName(response.data.winnerName);
        setIsGameFinished(false);
        setShotCount(0);
      })
      .catch((data) => console.error(data));
  };

  const onNextMove = () => {
    if (!shotsArray || !firstPlayer || !secondPlayer) {
      return;
    }

    let nextShot = shotsArray[shotCount];
    if (shotsArray.length === shotCount) {
      setIsGameFinished(true);
    }
    let firedUponPlayer = isFirstPlayerTurn
      ? { ...secondPlayer }
      : { ...firstPlayer };
    let tiles = [...firedUponPlayer.board.tiles];
    let hitTile = tiles.find(
      (t) =>
        t.coordinates.column === nextShot.hitPosition.column &&
        t.coordinates.row === nextShot.hitPosition.row
    );
    if (hitTile) {
      hitTile.isHit = true;
      if (hitTile.ship) {
        hitTile.ship.hitsTaken++;
        let ship = firedUponPlayer.ships.find(
          (ship) => ship.name === hitTile?.ship.name
        );
        ship && ship.hitsTaken++;
      }
      isFirstPlayerTurn
        ? setSecondPlayer({ ...secondPlayer })
        : setFirstPlayer({ ...firstPlayer });
    }

    setShotCount(shotCount + 1);
    setIsFirstPlayerTurn(!isFirstPlayerTurn);
  };
  return (
    <Container maxWidth="md">
      <Box sx={{ my: 4 }} alignItems="center" justifyContent="center">
        <Typography variant="h4" component="h1" gutterBottom>
          Battleship game
        </Typography>
        <div className="button-panel">
          <Button variant="contained" onClick={onGenerate}>
            Generate new game
          </Button>

          {shotsArray && (
            <>
              <Typography variant="h6" component="h1" gutterBottom>
                {`Current shot: ${shotCount}/${shotsArray.length}`}
              </Typography>
              {isGameFinished ? (
                <Typography variant="h6" component="h1" gutterBottom>
                  {`${winnerName} won!`}
                </Typography>
              ) : (
                <Button variant="outlined" onClick={onNextMove}>
                  {"Next shot >"}
                </Button>
              )}
            </>
          )}
        </div>
        <div className="player-board-container">
          {firstPlayer && (
            <PlayerPanel player={firstPlayer} isGameFinished={isGameFinished} />
          )}
          {secondPlayer && (
            <PlayerPanel
              player={secondPlayer}
              isGameFinished={isGameFinished}
            />
          )}
        </div>
      </Box>
    </Container>
  );
}

export default GameContainer;
