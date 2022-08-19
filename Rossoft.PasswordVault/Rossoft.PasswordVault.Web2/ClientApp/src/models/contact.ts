export interface Contact {
  id: number;
  name: string;
  email: string;
  phone: string;
  notes: string;
  isprimary: boolean;
  companyid: number;
}

export interface ContactToRemove {
  id: number;
  name: string;
}
