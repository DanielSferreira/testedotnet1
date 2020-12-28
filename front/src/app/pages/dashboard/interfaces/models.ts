export interface Dev {
  desenvolvedorTableId?: number,
  Nome: string,
  Cargo: string,
  ValorH: number
}
export interface DevInProjeto {
  id?: number,
  desenvolvedor: string,
  projetoTableId: number
}
export interface Projeto {
  Id?: number,
  projeto: string,
  descricao: string,
  devsEmProjetosTable?: DevInProjeto[]
}
export interface BancoHoras {
  id?: number,
  bancoId?: number,
  dataIni: string,
  dataFim: string,
  desenvolvedor: string
}
export interface TopFive {
  id?: number,
  desenvolvedor: string
  horasAcomuladas: number,
}