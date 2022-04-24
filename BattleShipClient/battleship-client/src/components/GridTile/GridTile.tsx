import { Paper } from "@mui/material";
import { Tile } from "../../api/types/games.types";
import "./styles.scss";

function GridTile(props: gridTileProps) {
  return (
    <Paper
      variant="outlined"
      className={props.tile.ship ? `tile tile-ship` : `tile`}
    >
      {/* {`${props.tile.coordinates.row} ${props.tile.coordinates.column}`} */}
      {props.tile.isHit ? "X" : ""}
    </Paper>
  );
}

interface gridTileProps {
  tile: Tile;
}

export default GridTile;
