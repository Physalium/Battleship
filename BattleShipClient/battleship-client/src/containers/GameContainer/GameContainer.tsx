import { Box, Button, Container, Typography } from "@mui/material";
import Grid from "@mui/material/Grid";
import React, { useState } from "react";
import { Player } from "../../api/types/games.types";
import { generateGameApi } from "../../api/utils.game";
import PlayerPanel from "../PlayerPanel/PlayerPanel";

function GameContainer() {
  const [firstPlayer, setFirstPlayer] = useState<Player>();
  const [secondPlayer, setSecondPlayer] = useState<Player>();

  const onGenerate = () => {
    generateGameApi()
      .then((response) => {
        console.log(response.data);
        setFirstPlayer(response.data.player1);
        setSecondPlayer(response.data.player2);
      })
      .catch((data) => console.error(data));
  };
  return (
    <Container maxWidth="md">
      <Box sx={{ my: 4 }} alignItems="center" justifyContent="center">
        <Typography variant="h4" component="h1" gutterBottom>
          Battleship game
        </Typography>
        <Button variant="contained" onClick={onGenerate}>
          Generate new game
        </Button>
        {firstPlayer && <PlayerPanel player={firstPlayer} />}
      </Box>
    </Container>
  );
}

export default GameContainer;
