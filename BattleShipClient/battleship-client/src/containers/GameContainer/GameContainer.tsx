import { Box, Button, Container, Typography } from "@mui/material";
import Grid from "@mui/material/Grid";
import React, { useState } from "react";
import { Player, Shot } from "../../api/types/games.types";
import { generateGameApi } from "../../api/utils.game";
import PlayerPanel from "../PlayerPanel/PlayerPanel";
import "./styles.scss";

function GameContainer() {
  const [firstPlayer, setFirstPlayer] = useState<Player>();
  const [secondPlayer, setSecondPlayer] = useState<Player>();
  const [shotsArray, setShotsArray] = useState<Shot[]>();
  const [shotCount, setShotCount] = useState<number>(0);
  const [isFirstPlayerTurn, setIsFirstPlayerTurn] = useState<boolean>(true);

  const onGenerate = () => {
    generateGameApi()
      .then((response) => {
        console.log(response.data);
        setFirstPlayer(response.data.player1);
        setSecondPlayer(response.data.player2);
        setShotsArray(response.data.shots);
      })
      .catch((data) => console.error(data));
  };

  const onNextMove = () => {
    if (!shotsArray) {
      return;
    }

    let nextShot = shotsArray[shotCount];
    let firedUponPlayer = isFirstPlayerTurn ? secondPlayer : firstPlayer;
    let hitTile = firedUponPlayer?.board.tiles.find(
      (t) =>
        t.coordinates.column === nextShot.hitPosition.column &&
        t.coordinates.row === nextShot.hitPosition.row
    );
    if (hitTile) {
      //let player =
      hitTile.isHit = true;
      if (hitTile.ship) {
        hitTile.ship.hitsTaken++;
      }
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
              <Button variant="outlined" onClick={onNextMove}>
                {"Next shot >"}
              </Button>
            </>
          )}
        </div>
        <div className="player-board-container">
          {firstPlayer && <PlayerPanel player={firstPlayer} />}
          {secondPlayer && <PlayerPanel player={secondPlayer} />}
        </div>
      </Box>
    </Container>
  );
}

export default GameContainer;
