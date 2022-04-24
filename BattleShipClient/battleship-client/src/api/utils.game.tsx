import { instance } from "./instance";
import { GenerateGameResponse } from "./types/games.types";

// generate game
export const generateGameApi = async () => {
  return await instance.get<GenerateGameResponse>(`/generate`);
};
