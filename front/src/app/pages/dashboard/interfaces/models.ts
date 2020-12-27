export interface Dev {
  desenvolvedorTableId?:number,
  Nome:string,
  Cargo: string,
  ValorH:string
} 
export interface DevInProjeto {
  id?:number,
  desenvolvedor:string,
  projetoTableId: number
} 
export interface Projeto {
  Id?:number,
  projeto:string,
  descricao: string,
  devsEmProjetosTable?:DevInProjeto[]
} 