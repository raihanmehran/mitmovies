import { Photo } from './photo';

export interface User {
  userId: number;
  username: string;
  token: string;
  firstName: string;
  lastName: string;
  roles: string[];
  photos: Photo[];
}
