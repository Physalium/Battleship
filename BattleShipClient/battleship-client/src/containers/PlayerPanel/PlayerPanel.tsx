import { Card, CardContent, Grid, Typography } from "@mui/material";
import { Player } from "../../api/types/games.types";
import GridTile from "../../components/GridTile/GridTile";

function PlayerPanel(props: playerPanelProps) {
  return (
    <>
      <Card variant="outlined">
        <CardContent>
          <Typography variant="h6" component="h1" gutterBottom>
            {props.player.name}
          </Typography>
          {props.player.ships.map((s) => (
            <Typography variant="body2" key={s.name}>
              {`${s.name} hits taken: ${s.hitsTaken}/${s.size}`}
            </Typography>
          ))}
        </CardContent>
      </Card>
      <Grid container columns={10} spacing={0}>
        {props.player.board.tiles.map((tile) => (
          <Grid
            item
            xs={1}
            key={`${tile.coordinates.row}${tile.coordinates.column}`}
          >
            <GridTile tile={tile} />
          </Grid>
        ))}
      </Grid>
    </>
  );
}

export interface playerPanelProps {
  player: Player;
  isGameFinished: boolean;
}

export default PlayerPanel;
