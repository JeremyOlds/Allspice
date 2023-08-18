

export class Recipe {
  constructor(data) {
    this.id = data.id
    this.title = data.title
    this.category = data.category
    this.creatorId = data.creatorId
    this.Creator = data.creator
    this.img = data.img
    this.instructions = data.instructions
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)

  }
}