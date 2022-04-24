import { Grid } from "@mui/material";
import { Player } from "../../api/types/games.types";
import GridTile from "../../components/GridTile/GridTile";

function PlayerPanel(props: playerPanelProps) {
  return (
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
  );
}

export interface playerPanelProps {
  player: Player;
}

export default PlayerPanel;
