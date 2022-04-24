import React from "react";
import "./App.scss";
import Container from "@mui/material/Container";
import GameContainer from "./containers/GameContainer/GameContainer";

function App() {
  return (
    <Container maxWidth="sm">
      <GameContainer />
    </Container>
  );
}

export default App;
