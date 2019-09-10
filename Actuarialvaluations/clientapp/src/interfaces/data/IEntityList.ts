/**
 * The Entity List interface
 */
export interface IEntityList<T> {
    /**
     * The total number of records
     */
    Total: number;
  
    /**
     * The entities
     */
    Entities: T[];
  }