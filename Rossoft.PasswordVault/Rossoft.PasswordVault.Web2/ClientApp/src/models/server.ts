export interface Server {
  id: number;
  name: string;
  username: string;
  password: string;
  notes: string;
  isExpanded: boolean;
  address: string;
  companyid: number;
}

export interface ServerToRemove {
  id: number;
  name: string;
}
