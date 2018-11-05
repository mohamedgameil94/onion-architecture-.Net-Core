using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Infrastructure
{
    public interface ITokenProvider
    {
        string GenerateTokenIdentity(string Id);
        string GenerateTokenIdentity(string Id,DateTime Expires);
    }
}
