using System;
using System.Collections.Generic;

namespace MyVirtualStore.Models;

public partial class Marca
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
