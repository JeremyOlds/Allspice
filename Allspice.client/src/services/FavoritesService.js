import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class FavoritesService {
  async getFavorites() {
    const res = await api.get('account/favorites')
    logger.log('favorites res data', res.data)
    const favorites = res.data.map(f => new Favorite(f))
    logger.log('mapped res data', favorites)
    AppState.favorites = favorites
    logger.log('appstate favorites', AppState.favorites)
  }
  async createFavorite(favoriteData) {
    const res = await api.post('api/favorites', favoriteData)
    logger.log('favorites res data', res.data)
    const favorite = new Favorite(res.data)
    logger.log('new favorite', favorite)
    AppState.favorites.push(favorite)
    logger.log('appstate new favorite', AppState.favorites)
  }
  async removeFavorite(favoriteId) {
    const res = await api.delete(`api/favorites/${favoriteId}`)

    const favoriteIndex = AppState.favorites.findIndex(f => f.id == favoriteId)
    AppState.favorites.splice(favoriteIndex, 1)

  }
}


export const favoritesService = new FavoritesService()