#!/usr/bin/env bash
# phxspec — run an XSpec suite on PhoenixmlDb. No JVM, no Saxon.
set -euo pipefail
exec phxspec "$@"
